using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace ScheduleManagement.Ui
{
    public sealed partial class App : Application
    {
        public App()
        {
            this.InitializeComponent();

            var bootstrapper = new AppBootstrapper();
            bootstrapper.Run();
        }
    }
}
