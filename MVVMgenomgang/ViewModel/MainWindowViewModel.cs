using MVVMgenomgang.Model;
using MVVMgenomgang.MVVM;
using System.Collections.ObjectModel;

namespace MVVMgenomgang.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        public ObservableCollection<Item> Items { get; set; }

        //Alternativ 1
        //public RelayCommand AddCommand => new RelayCommand(execute => AddItem());
        //public RelayCommand DeleteCommand => new RelayCommand(execute => DeleteItem(), canExecute => selectedItem != null);


        //Alternativ 2
        private RelayCommand addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                if (addCommand == null)
                {
                    addCommand = new RelayCommand(ExecuteAddItem);
                }
                return addCommand;
            }

        }

        private void ExecuteAddItem(object parameter)
        {
            AddItem();
        }
        private void AddItem()
        {
            Items.Add(new Item { Name = "New Item", SerieNbr = "XXXX", Quantity = 2 });
        }

        private RelayCommand deleteCommand;

        public RelayCommand DeleteCommand
        {
            get
            {
                if (deleteCommand == null)
                {
                    deleteCommand = new RelayCommand(ExecuteDeleteItem, CanExecuteDeleteItem);
                }
                return deleteCommand;
            }

        }
        private bool CanExecuteDeleteItem(object parameter)
        {
            return selectedItem != null;
        }

        private void ExecuteDeleteItem(object parameter)
        {
            DeleteItem();
        }

        private void DeleteItem()
        {
            Items.Remove(selectedItem);
        }


        public MainWindowViewModel()
        {
            Items = new ObservableCollection<Item>();

            Items.Add(new Item { Name = "Product1", SerieNbr = "0000", Quantity = 10 });
            Items.Add(new Item { Name = "Product2", SerieNbr = "0001", Quantity = 20 });
        }


        private Item selectedItem;
        public Item SelectedItem
        {
            get { return selectedItem; }
            set
            {
                selectedItem = value;
                OnPropertyChanged();
            }
        }



    }
}
