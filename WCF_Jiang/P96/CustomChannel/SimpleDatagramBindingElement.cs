using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;

namespace CustomChannel
{
    public class SimpleDatagramBindingElement:BindingElement
    {
        public SimpleDatagramBindingElement()
        {
            PrintHelper.Print(this,"SimpleDatagramBindingElement");
        }

        public override BindingElement Clone()
        {
            PrintHelper.Print(this,"Clone");
            return new SimpleDatagramBindingElement();
        }

        public override T GetProperty<T>(BindingContext context)
        {
            PrintHelper.Print(this,string.Format("GetProperty<{0}>",typeof(T).Name));
            return context.GetInnerProperty<T>();
        }

        public override IChannelFactory<TChannel> BuildChannelFactory<TChannel>(BindingContext context)
        {
            PrintHelper.Print(this,"BuildChannelFactory<TChannel>");
            return new SimpleDatagramChanelFactory<TChannel>(context) as IChannelFactory<TChannel>;
        }

        public override IChannelListener<TChannel> BuildChannelListener<TChannel>(BindingContext context)
        {
            PrintHelper.Print(this, "BuildChannelListener<TChannel>");
            return new SimpleDatagramChannelListener<TChannel>(context) as IChannelListener<TChannel>;
        }
    }
}
