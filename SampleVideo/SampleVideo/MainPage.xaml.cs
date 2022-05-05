using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediaManager;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;

namespace SampleVideo
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void Handle_Clicked(object sender, EventArgs e)
        {
            try
            {
                await CrossMediaManager.Current.Play("file:///android_asset/big_buck_bunny.mp4");
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private async void Handle_Clicked2(object sender, EventArgs e)
        {
            try
            {
                var file = await FileSystem.OpenAppPackageFileAsync("big_buck_bunny.mp4");
                using (var ms = new MemoryStream())
                {
                    await file.CopyToAsync(ms);
                    
                    
                    
                    
                    
                    var bytes = ms.ToArray();
                    using (var ms2 = new MemoryStream(bytes))
                    {
                        await CrossMediaManager.Current.Play(ms2, $"{Guid.NewGuid()}.mp4");
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
