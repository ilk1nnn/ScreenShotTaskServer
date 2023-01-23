using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using TcpServerToClientSendSS.ViewModels;

namespace TcpServerToClientSendSS.AddditionalClasses
{
    public class Network
    {
        public void StartTcpServer()
        {
            TcpListener server = null;
            try
            {
                App.MainViewModel.AllScreens = new System.Collections.ObjectModel.ObservableCollection<StackPanel>();
                IPAddress localAddr = IPAddress.Parse(NetworkProtocol.IPAddress);
                server = new TcpListener(localAddr, NetworkProtocol.TcpPort);
                server.Start();
                byte[] bytes = new byte[3000000];
                while (true)
                {
                    TcpClient client = server.AcceptTcpClient();
                    int c = 0;
                    while (true)
                    {

                        // we can add foreach
                        // Get a stream object for reading and writing
                        NetworkStream stream = client.GetStream();
                        int i;
                        string path = String.Empty;
                        // Loop to receive all the data sent by the client.
                        while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                        {

                            ImageHelper imageHelper = new ImageHelper();
                            path = imageHelper.GetImagePath(bytes, ++c);

                            Task.Run(() =>
                            {
                                App.Current.Dispatcher.Invoke(() =>
                                {
                                    App.MainViewModel.Source = path;
                                    Uri imageUri = new Uri(path,UriKind.Relative);
                                    BitmapImage bitmapImage= new BitmapImage(imageUri);
                                    Image image = new Image();
                                    image.Source = bitmapImage;
                                    App.MainViewModel.StackPanel.Children.Add(image);
                                    //String stringPath = "Pictures/myPicture.jpg";
                                    //Uri imageUri = new Uri(stringPath, UriKind.Relative);
                                    //BitmapImage imageBitmap = new BitmapImage(imageUri);
                                    //Image myImage = new Image();
                                    //myImage.Source = imageBitmap;
                                    //ScreenClass screenClass = new ScreenClass();
                                    //screenClass.Source = path;
                                    //App.MainViewModel.AllScreens.Add(screenClass);
                                });

                            });
                        }
                    }
                    client.Close();
                }
            }
            catch (SocketException e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                server.Stop();
            }
        }

    }
}
