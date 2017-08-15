using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;

namespace CustomChannel
{
    public class SimpleSessionChannelFactory<TChannel>:ChannelFactoryBase<TChannel>
    {
        private IChannelFactory<TChannel> _innerChannelFactory;

        public SimpleSessionChannelFactory(BindingContext context)
        {
            PrintHelper.Print(this,"SimpleSessionChannelFactory");
            this._innerChannelFactory = context.BuildInnerChannelFactory<TChannel>();
        }

        protected override void OnOpen(TimeSpan timeout)
        {
            PrintHelper.Print(this,"OnOpen");
            this._innerChannelFactory.Open(timeout);
        }

        protected override IAsyncResult OnBeginOpen(TimeSpan timeout, AsyncCallback callback, object state)
        {
            PrintHelper.Print(this,"OnBeginOpen");
            return this._innerChannelFactory.BeginOpen(timeout, callback, state);
        }

        protected override void OnEndOpen(IAsyncResult result)
        {
            PrintHelper.Print(this,"OnEndOpen");
            this._innerChannelFactory.EndOpen(result);
        }

        protected override TChannel OnCreateChannel(EndpointAddress address, Uri via)
        {
            PrintHelper.Print(this,"OnCreatChannel");
            return (TChannel)(object)new SimpleDuplexSessionChannel(this,this._innerChannelFactory.CreateChannel(address,via) as SimpleDuplexSessionChannel);
        }

        public override T GetProperty<T>()
        {
            return this._innerChannelFactory.GetProperty<T>();
        }
    }
}
