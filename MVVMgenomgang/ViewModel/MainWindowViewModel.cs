using MVVMgenomgang.Model;
using MVVMgenomgang.MVVM;
using System.Collections.ObjectModel;

namespace MVVMgenomgang.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        public ObservableCollection<Item> Items { get; set; }




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
