using System.Collections.ObjectModel;

namespace AIRE_App.ViewModels;

public class GroupViewModel<Item> : ItemViewModel where Item : ItemViewModel
{
    public Action<GroupViewModel<Item>> LoadItems;

    public bool IsExpanded
    {
        get;
        set
        {
            field = value;
            OnPropertyChanged();
        }
    }
    public override bool IsChecked
    {
        get => isChecked;
        set
        {
            if (isChecked != value)
            {
                isChecked = value;

                if (value)
                {
                    LoadItems?.Invoke(this);
                }

                if (Items != null)
                {
                    foreach (var item in Items)
                    {
                        item.IsChecked = value;
                    }

                    IsExpanded = value ? value : IsExpanded;
                }

                ParentItemCheck?.Invoke(value);

                OnPropertyChanged();
            }
        }
    }

    public ObservableCollection<Item> Items
    {
        get;
        set
        {
            field = value;
            OnPropertyChanged();
        }
    }

    public void SubItemCheck(bool isChecked)
    {
        if (this.isChecked != isChecked)
        {
            if (isChecked || (Items?.All(item => !item.IsChecked) ?? false))
            {
                this.isChecked = isChecked;

                ParentItemCheck?.Invoke(isChecked);

                OnPropertyChanged(nameof(IsChecked));
            }
        }
    }
}