using PrismEvents = Microsoft.Practices.Prism.PubSubEvents;

namespace KeeperRichClient.Infrastructure
{
    public sealed class ApplicationService
    {
        private ApplicationService() { }

        private static readonly ApplicationService _instance = new ApplicationService();

        public static ApplicationService Instance { get { return _instance; } }

        private PrismEvents.IEventAggregator _eventAggregator;
        public  PrismEvents.IEventAggregator EventAggregator
        {
            get
            {
                if (_eventAggregator == null)
                    _eventAggregator = new PrismEvents.EventAggregator();

                return _eventAggregator;
            }
        }

        
        
    }
}

