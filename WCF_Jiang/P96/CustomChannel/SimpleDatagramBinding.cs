using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;

namespace CustomChannel
{
    public class SimpleDatagramBinding:Binding
    {
        private TransportBindingElement _transportBindingElement=new HttpTransportBindingElement();
        private MessageEncodingBindingElement _messageEncodingBindingElement=new TextMessageEncodingBindingElement();
        private SimpleDatagramBindingElement _simpleDatagramBindingElement=new SimpleDatagramBindingElement();
        public override BindingElementCollection CreateBindingElements()
        {
            BindingElementCollection elements=new BindingElementCollection();
            elements.Add(this._simpleDatagramBindingElement);
            elements.Add(this._messageEncodingBindingElement);
            elements.Add(this._transportBindingElement);
            return elements;
        }

        public override string Scheme {
            get { return this._transportBindingElement.Scheme; }
        }
    }
}
