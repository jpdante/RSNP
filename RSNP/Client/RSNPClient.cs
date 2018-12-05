using RSNP.Logging;
using System;
using System.Net;
using System.Net.Sockets;
using System.Reflection;

namespace RSNP {
    public class RSNPClient : IDisposable {

        #region Events
        public delegate void OnConnectHandler(object sender, bool connected);
        public event OnConnectHandler OnConnect;

        public delegate void OnDisconnectHandler(object sender, bool disconnected);
        public event OnDisconnectHandler OnDisconnect;
        #endregion

        private ILog logger = LogManager.NewLog(MethodBase.GetCurrentMethod().DeclaringType);
        private Socket socket;

        public RSNPClient(AddressFamily addressFamily = AddressFamily.InterNetwork) {
            socket = new Socket(addressFamily, SocketType.Stream, ProtocolType.Tcp);
        }

        #region Connect Region
        public void Connect(IPEndPoint endPoint) {
            try {
                socket.Connect(endPoint);
                OnConnect(this, true);
            } catch (Exception ex) {
                logger.Error(ex);
                OnConnect(this, false);
            }
        }

        public void ConnectTask(IPEndPoint endPoint) {
            socket.BeginConnect(endPoint, new AsyncCallback(ConnectCallback), socket);
        }
        #endregion

        #region Disconnect Region
        public void Disconnect(bool reuseSocket) {
            try {
                socket.Disconnect(reuseSocket);
                OnDisconnect(this, true);
            } catch(Exception ex) {
                logger.Error(ex);
                OnDisconnect(this, false);
            }
        }

        public void DisconnectTask(bool reuseSocket) {
            socket.BeginDisconnect(reuseSocket, new AsyncCallback(DisconnectCallback), socket);
        }
        #endregion

        #region Callbacks Region
        internal void ConnectCallback(IAsyncResult ar) {
            try {
                Socket s = (Socket)ar.AsyncState;
                s.EndConnect(ar);
                OnConnect(this, true);
            } catch(Exception ex) {
                logger.Error(ex);
                OnConnect(this, false);
            }
        }

        internal void DisconnectCallback(IAsyncResult ar) {
            try {
                Socket s = (Socket)ar.AsyncState;
                s.EndDisconnect(ar);
                OnDisconnect(this, true);
            } catch (Exception ex) {
                logger.Error(ex);
                OnDisconnect(this, false);
            }
        }
        #endregion


        public void Dispose() {
            LogManager.DeleteLog(logger.Type);
            logger = null;
            socket.Dispose();
            socket = null;
        }

    }
}
