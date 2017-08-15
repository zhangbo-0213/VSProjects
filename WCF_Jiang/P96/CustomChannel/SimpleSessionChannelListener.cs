using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;

namespace CustomChannel
{
    public class SimpleSessionChannelListener<TChannel>:ChannelListenerBase<TChannel> where TChannel:class,IChannel
    {
        private IChannelListener<TChannel> _channelListener;

        public SimpleSessionChannelListener(BindingContext context)
        {
            PrintHelper.Print(this,"SimpleChannelListener");
            this._channelListener = context.BuildInnerChannelListener<TChannel>();
        }

        protected override void OnAbort()
        {
            PrintHelper.Print(this,"OnAbort");
            this._channelListener.Abort();
        }

        protected override void OnClose(TimeSpan timeout)
        {
            PrintHelper.Print(this,"Close");
            this._channelListener.Close(timeout);
        }

        protected override void OnEndClose(IAsyncResult result)
        {
            PrintHelper.Print(this,"EndClose");
            this._channelListener.EndClose(result);
        }

        protected override IAsyncResult OnBeginClose(TimeSpan timeout, AsyncCallback callback, object state)
        {
            PrintHelper.Print(this,"OnBeginClose");
            return this._channelListener.BeginClose(timeout,callback,state);
        }

        protected override void OnOpen(TimeSpan timeout)
        {
            PrintHelper.Print(this,"OnOpen");
            this._channelListener.Open(timeout);
        }

        protected override IAsyncResult OnBeginOpen(TimeSpan timeout, AsyncCallback callback, object state)
        {
            PrintHelper.Print(this,"OnBeginOpen");
            return this._channelListener.BeginOpen(timeout, callback, state);
        }

        protected override void OnEndOpen(IAsyncResult result)
        {
            PrintHelper.Print(this,"EndOpen");
            this._channelListener.EndOpen(result);
        }

        protected override bool OnWaitForChannel(TimeSpan timeout)
        {
            PrintHelper.Print(this,"OnWaitForChannel");
            return this._channelListener.WaitForChannel(timeout);
        }

        protected override IAsyncResult OnBeginWaitForChannel(TimeSpan timeout, AsyncCallback callback, object state)
        {
            PrintHelper.Print(this,"OnBeginWaitForChannel");
            return this._channelListener.BeginAcceptChannel(timeout, callback, state);
        }

        protected override bool OnEndWaitForChannel(IAsyncResult result)
        {
            PrintHelper.Print(this,"OnEndWaitForChannel");
            return this._channelListener.EndWaitForChannel(result);
        }

        public override Uri Uri {
            get
            {
                PrintHelper.Print(this,"Uri");
                return this._channelListener.Uri;
            }
        }
        protected override TChannel OnAcceptChannel(TimeSpan timeout)
        {
            PrintHelper.Print(this,"OnAcceptChannel");
            IDuplexSessionChannel innerChannel=this._channelListener.AcceptChannel(timeout) as IDuplexSessionChannel;
            return new SimpleDuplexSessionChannel(this,innerChannel) as TChannel;
        }

        protected override IAsyncResult OnBeginAcceptChannel(TimeSpan timeout, AsyncCallback callback, object state)
        {
            PrintHelper.Print(this,"OnBeginAcceptChannel");
            return this._channelListener.BeginAcceptChannel(timeout, callback, state);
        }

        protected override TChannel OnEndAcceptChannel(IAsyncResult result)
        {
            PrintHelper.Print(this,"OnEndAcceptChannel");
            return new SimpleDuplexSessionChannel(this,this._channelListener.EndAcceptChannel(result) as IDuplexSessionChannel) as TChannel;
        }

        public override T GetProperty<T>()
        {
            return this._channelListener.GetProperty<T>();
        }
    }
}
