using System;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Graviton_Manager
{
    public class Server
    {
        private string ip;
        private int port;
        private Thread listenThread;
        private Stream stream;
        private TcpClient client = new TcpClient();

        public splashScreen firstForm = new splashScreen();
        public MainForm secondForm = new MainForm();

        public Server(String ip, int port)
        {
            this.ip = ip;
            this.port = port;
            this.listenThread = new Thread(listen);
            this.firstForm.Server = this;
            this.secondForm.Server = this;
            connect();
        }

        private void listen()
        {
            try
            {
                int read = 0;
                while (client.Connected)
                {
                    byte[] buffer = new byte[client.ReceiveBufferSize];
                    read = stream.Read(buffer, 0, buffer.Length);
                    while (read > 0)
                    {
                        String packet = Encoding.ASCII.GetString(buffer);
                        if(packet[0] == 'A')
                        {
                            firstForm.alreayConnect();
                            return;
                        }
                        secondForm.parse(packet);
                        read = 0;
                    }
                }
                firstForm.disconnect();
            }
            catch
            {
                firstForm.disconnect();
            }
        }

        public void send(String packet)
        {
            Byte[] data = Encoding.ASCII.GetBytes(packet);
            stream.Write(data, 0, data.Length);
        }

    
        public async void connect()
        {
            try
            {
                await client.ConnectAsync(ip, port);
                if (client.Connected)
                {
                    this.stream = client.GetStream();
                    if (listenThread.ThreadState == ThreadState.Unstarted)
                    {
                        listenThread.Start();
                    }
                    sendIp();

                }
            }
            catch
            {

            }

        }

        private void sendIp()
        {
            string externalip = new System.Net.WebClient().DownloadString("http://ipinfo.io/ip").Replace(" ","");
            send("I" + externalip.Trim());
        }

        public Boolean isConnected()
        {
            return client.Connected;
        }

    }
}
