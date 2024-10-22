namespace ProjectSystemMauiHardNavigation
{
    public partial class MainPage : ContentPage
    {
        

        public MainPage()
        {
            InitializeComponent();

           
            BindingContext = new TaskMVVM();
        }


        

        protected override void OnAppearing()
        {
            ((TaskMVVM)BindingContext).OnAppearing();
        }

               
    }

}
