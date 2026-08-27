using System;
using System.Collections.ObjectModel;
using System.Reactive.Linq;
using DynamicData;
using ReactiveUI;
using ReactiveUI.SourceGenerators;
using SPW.Models;

namespace SPW.ViewModels;

public partial class Page2ViewModel : PageViewModelBase
{
    [Reactive] private TestDataVm? _selectedItem;

    [Reactive] private Guid? _id;
    [Reactive] private string? _name;
    [Reactive] private TimeOnly? _time;

    private SourceCache<TestData, Guid> _items { get; } = new(x => x.Id);
    
    private ReadOnlyObservableCollection<TestDataVm> _itemsVm;
    public ReadOnlyObservableCollection<TestDataVm> Items => _itemsVm;

    private IObservable<bool> _canSave;
    private IObservable<bool> _canDelete;
    private IObservable<bool> _canClear;

    public Page2ViewModel(string text)
        : base(text)
    {
        _items.Connect()
            .Transform(i => new TestDataVm()
            {
                Id = i.Id,
                Name = i.Name,
                Time = i.Time
            })
            .ObserveOn(RxApp.MainThreadScheduler)
            .Bind(out _itemsVm)
            .DisposeMany()
            .Subscribe();
        
        this.WhenAnyValue(vm => vm.SelectedItem)
            .Subscribe(item =>
            {
                Id = item?.Id;
                Name = item?.Name;
                Time = item?.Time;
            });
        
        _canSave = this.WhenAnyValue(vm => vm.Name)
                .Select(name => !string.IsNullOrWhiteSpace(name));
        _canDelete = this.WhenAnyValue(vm => vm.SelectedItem)
            .Select(item => item != null);
        _canClear = this.WhenAnyValue(vm => vm.Id,
            vm => vm.Name,
            vm => vm.Time,
            (p1, p2, p3) => p1 != null || p2 != null || p3 != null);
        
        
        _items.AddOrUpdate(new TestData()
        {
            Name = "Test"
        });
    }
    
    [ReactiveCommand(CanExecute = nameof(_canSave))]
    private void Save()
    {
        if (Id == null)
        {
            var newItem = new TestData
            {
                Name = Name!,
                Time = Time ?? TimeOnly.FromDateTime(DateTime.Now)
            };
            _items.AddOrUpdate(newItem);
        }
        else
        {
            var existing = _items.Lookup(Id.Value);
            if (existing.HasValue)
            {
                var updated = existing.Value with 
                { 
                    Name = Name!, 
                    Time = Time ?? existing.Value.Time 
                };
                _items.AddOrUpdate(updated);
            }
        }
        
        Clear();
    }

    [ReactiveCommand(CanExecute = nameof(_canDelete))]
    private void Delete()
    {
        _items.Remove(SelectedItem!.Id);
        
        Clear();
    }

    [ReactiveCommand(CanExecute = nameof(_canClear))]
    private void Clear()
    {
        SelectedItem = null;
    }
}