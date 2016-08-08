using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Patterns
{
    public interface IPublisher
    {
        void Publish(Topic topic);
        void Subscribe(Topic topic, ISubscriber subscriber);
        void UnSubscribe(Topic topic, ISubscriber subscriber);
    }

    public class Publisher : IPublisher
    {
        Dictionary<Topic, List<ISubscriber>> _topicSubscribers;
        public Publisher(Dictionary<Topic, List<ISubscriber>> topicSubscribers)
        {
            _topicSubscribers = topicSubscribers;
        }
        public void Publish(Topic topic)
        {
            foreach (var subscriber in _topicSubscribers[topic])
            {
                subscriber.Update(topic);
            }
        }
        public void Subscribe(Topic topic, ISubscriber subscriber)
        {
            if (_topicSubscribers[topic] == null)
                _topicSubscribers[topic] = new List<ISubscriber>();
            _topicSubscribers[topic].Add(subscriber);
        }
        public void UnSubscribe(Topic topic, ISubscriber subscriber)
        {
            if (_topicSubscribers[topic] != null)
                _topicSubscribers[topic].Remove(subscriber);
            Console.WriteLine(subscriber.Name + " is unsubscribed");
        }
    }

    public interface ISubscriber
    {
        string Name { get; set; }
        void Update(Topic topic);
    }

    public class Subscriber : ISubscriber
    {
        public string Name { get; set; }
        public Subscriber(string name)
        {
            Name = name;
        }
        public void Update(Topic topic)
        {
            Console.WriteLine("Triggered for " + Name);
        }
    }

    public class Topic
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}