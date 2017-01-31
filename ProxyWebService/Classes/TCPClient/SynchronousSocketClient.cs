using System;
using System.Configuration;
using System.Net;
using System.Net.Sockets;
using System.Text;

public class SynchronousSocketClient
{
    const string _host = "10.120.130.100"; //Servidor en McDonalds
    const int _port = 7305; //Servidor en McDonalds
    public static string WriteAndGetReply(string message, string host = _host, int port = _port)
    {
        host = ConfigurationManager.AppSettings["TarjetaMI_ServerIP"];
        port = int.Parse(ConfigurationManager.AppSettings["TarjetaMI_ServerPort"]);

        byte[] bytes = new byte[8192];
        string response = string.Empty;
        // Connect to a remote device.
        try
        {
            IPAddress ipAddress = IPAddress.Parse(host);
            IPEndPoint remoteEP = new IPEndPoint(ipAddress, port);

            Socket sender = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                sender.Connect(remoteEP);
                byte[] msg = Encoding.UTF8.GetBytes(string.Format("{0}\r\n", message));
                int bytesSent = sender.Send(msg);
                int bytesRec = sender.Receive(bytes);
                response = Encoding.UTF8.GetString(bytes, 0, bytesRec);
                sender.Shutdown(SocketShutdown.Both);
                sender.Close();
            }
            catch (ArgumentNullException ane)
            {
                return ane.Message;
            }
            catch (SocketException se)
            {
                return se.Message;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        catch (Exception e)
        {
            return e.Message;
        }
        return response;
    }

}