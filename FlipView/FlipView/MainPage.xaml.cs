using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FlipView
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            places = GetPlaces();
            this.BindingContext = this;

        }

        public ObservableCollection<Place> places;

        public ObservableCollection<Place> Places
        {   get { return places; }
            set
            {
                places = value;
                OnPropertyChanged();
            }
        }

        private async Task Flip( VisualElement from, VisualElement to)
        {
            await from.RotateYTo(-90, 300, Easing.SpringIn);
            to.RotationY = 90;
            to.IsVisible = true;
            from.IsVisible = false;
            await to.RotateYTo(0, 250, Easing.SpringOut);
        }

        private async void FlipToBack(object sender, EventArgs e)
        {
            var front = sender as Grid;
            var back = front.Parent.FindByName<Grid>("BackView");
            await Flip(front, back);
        }
        private async void FlipToFront(object sender, EventArgs e)
        {
            var back = sender as Grid;
            var front = back.Parent.FindByName<Grid>("FrontView");
            await Flip(back, front);
        }

        private ObservableCollection<Place> GetPlaces()
        {
            return new ObservableCollection<Place>
            {
                new Place
                {
                    Name = "R1 800 000",
                    Caption = "For Sale in Cape Town Western Cape",
                    Image = "house4.jpg",
                    Description = $"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed sagittis risus elit, id interdum leo rhoncus a. Praesent eleifend metus vitae lorem egestas aliquam vel ac massa. In nulla urna, consequat ac sem in, facilisis scelerisque lacus",
                    Bedrooms = "4",
                    Bathrooms = "2",
                    Garage = "1",
                    Area = "222 m²",
                    pic1 = "pic1.png",
                    pic2 = "pic2.png",
                    pic3 = "pic3.png",
                    pic4 = "pic.png"
                },
                  new Place
                {
                    Name = "R 4 450 005",
                    Caption = "For Sale in Diepsloot, Gauteng",
                    Image = "house3.jpg",
                    Description = $"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed sagittis risus elit, id interdum leo rhoncus a. Praesent eleifend metus vitae lorem egestas aliquam vel ac massa. In nulla urna, consequat ac sem in, facilisis scelerisque lacus",
                    Bedrooms = "10",
                    Bathrooms = "2",
                    Garage = "3",
                    Area = "258 m²",
                    pic1 = "house1.jpg",
                    pic2 = "house1.jpg",
                    pic3 = "house1.jpg",
                    pic4 = "house1.jpg"
                },
                new Place
                {
                    Name = "R 2 304 022",
                    Caption = "For Sale in Nelspruit, Mpumalanga",
                    Image = "house2.jpg",
                    Description = $"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed sagittis risus elit, id interdum leo rhoncus a. Praesent eleifend metus vitae lorem egestas aliquam vel ac massa. In nulla urna, consequat ac sem in, facilisis scelerisque lacus",
                    Bedrooms = "3",
                    Bathrooms = "2",
                    Garage = "1",
                    Area = "652 m²",
                    pic1 = "house1.jpg",
                    pic2 = "house1.jpg",
                    pic3 = "house1.jpg",
                    pic4 = "house1.jpg"
                },
                new Place
                {
                    Name = "R 4 450 005",
                    Caption = "For Sale in Pretoria, Gauteng",
                    Image = "house1.jpg",
                    Description = $"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed sagittis risus elit, id interdum leo rhoncus a. Praesent eleifend metus vitae lorem egestas aliquam vel ac massa. In nulla urna, consequat ac sem in, facilisis scelerisque lacus",
                    Bedrooms = "5",
                    Bathrooms = "2",
                    Garage = "2",
                    Area = "102 m²",
                    pic1 = "house1.jpg",
                    pic2 = "house1.jpg",
                    pic3 = "house1.jpg",
                    pic4 = "house1.jpg"

                }
            };
        }
    }

    public class Place
    {
        public string Name { get; set; }
        public string Caption { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string Bedrooms { get; set; }
        public string Bathrooms { get; set; }
        public string Garage { get; set; }
        public string Area { get; set; }
        public string pic1 { get; set; }
        public string pic2 { get; set; }
        public string pic3 { get; set; }
        public string pic4 { get; set; }

    }
}
