namespace AprajitaRetails.Mobile.TestSpace
{
    public class TestPage1 : ContentPage
    {
        public TestPage1()
        {
            Content = new Grid
            {
                Children =
                {
                    new Label
                    {
                        Text = "Welcome to .NET MAUI!!!",
                        TextColor = Colors.Purple,
                        HorizontalOptions = LayoutOptions.Center,
                        VerticalOptions = LayoutOptions.Center
                    }
                }
            };
        }
    }
}
