using System.Windows;
using System.Windows.Controls;
using WiredBrainCoffee.CustomersApp.Data;
using WiredBrainCoffee.CustomersApp.ViewModels;

namespace WiredBrainCoffee.CustomersApp.Views
{
    /// <summary>
    /// Interaction logic for CustomersView.xaml
    /// </summary>
    public partial class CustomersView : UserControl
    {
        private readonly CustomersViewGrid _customersViewGridPointer;
        private readonly CustomersViewModel _customersViewModel;

        public CustomersView()
        {
            InitializeComponent();
            _customersViewGridPointer = new CustomersViewGrid(this.customersViewGrid);

            _customersViewModel = new CustomersViewModel(new CustomerDataProvider());

            this.DataContext = _customersViewModel;
            Loaded += CustomersView_Loaded;
        }

        private async void CustomersView_Loaded(object sender, RoutedEventArgs e)
            => await _customersViewModel.LoadAsync();

        private void ButtonMoveNavigation_Click(object sender, RoutedEventArgs e)
          => _customersViewGridPointer.ResetGridColumn();

        private void Add_Customer(object sender, RoutedEventArgs e)
        {
            _customersViewModel.Add();
        }

        private sealed class CustomersViewGrid : Grid
        {
            private const int LHS_COLUMN = 0;
            private const int RHS_COLUMN = 2;
            public CustomersViewGrid(UIElement customersViewGridPointer)
            {
                CustomersViewGridPointer = customersViewGridPointer;
            }

            private UIElement CustomersViewGridPointer { get; set; }

            public void ResetGridColumn()
            {
                int currentColumn = GetCurrentColumn();
                SetCurrentColumn(currentColumn == LHS_COLUMN ? RHS_COLUMN : LHS_COLUMN);
            }

            private int GetCurrentColumn()
                => Grid.GetColumn(CustomersViewGridPointer);

            private void SetCurrentColumn(int newCurrentColumn)
                => Grid.SetColumn(CustomersViewGridPointer, newCurrentColumn);
        }

      
    }
}
