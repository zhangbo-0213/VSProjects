using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;

namespace CustomChannel
{
   public class SimpleDatagramChannelListener<TChannel>:ChannelListenerBase<TChannel> where    TChannel:class ,IChannel
   {
       private IChannelListener<TChannel> _channelListener;

       public SimpleDatagramChannelListener(BindingContext context)
       {
            PrintHelper.Print(this,"SimpleDatagramChannelListener");
           this._channelListener = context.BuildInnerChannelListener<TChannel>();
       }

       protected override void OnAbort()
       {
           PrintHelper.Print(this,"OnAbort");
            this._channelListener.Abort();
       }

       protected override void OnClose(TimeSpan timeout)
       {
           PrintHelper.Print(this,"OnClose");
            this._channelListener.Close();
       }

       protected override void OnEndClose(IAsyncResult result)
       {
           PrintHelper.Print(this,"OnEndClose");
           this._channelListener.EndClose(result);
       }

       protected override IAsyncResult OnBeginClose(TimeSpan timeout, AsyncCallback callback, object state)
       {
           PrintHelper.Print(this,"OnBeginClose");
           return this._channelListener.BeginClose(callback, state);
       }

       protected override void OnOpen(TimeSpan timeout)
       {
          PrintHelper.Print(this,"OnOpen");
          this._channelListener.Open(timeout);
       }

       protected override IAsyncResult OnBeginOpen(TimeSpan timeout, AsyncCallback callback, object state)
       {
           PrintHelper.Print(this,"OnBeginOpen");
           return this._channelListener.BeginOpen(callback, state);
       }

       protected override void OnEndOpen(IAsyncResult result)
       {
           PrintHelper.Print(this,"OnEndOpen");
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
           return this._channelListener.BeginAcceptChannel(timeout,callback, state);
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
            IReplyChannel innerChannel=this._channelListener.AcceptChannel(timeout) as IReplyChannel;
            return new SimpleReplyChannel(this,innerChannel) as TChannel;
       }

       protected override IAsyncResult OnBeginAcceptChannel(TimeSpan timeout, AsyncCallback callback, object state)
       {
           PrintHelper.Print(this,"OnBeginAcceptChannel");
           return this._channelListener.BeginAcceptChannel(timeout, callback, state);
       }

       protected override TChannel OnEndAcceptChannel(IAsyncResult result)
       {
           PrintHelper.Print(this,"OnEndAcceptChannel");
           return new SimpleReplyChannel(this,this._channelListener.EndAcceptChannel(result) as IReplyChannel) as TChannel;
       }
    }
}
