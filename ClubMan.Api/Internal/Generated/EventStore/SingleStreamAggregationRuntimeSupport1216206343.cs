// <auto-generated/>
#pragma warning disable
using Marten;
using Marten.Events.Aggregation;
using Marten.Internal.Storage;
using System;
using System.Linq;

namespace Marten.Generated.EventStore
{
    // START: SingleStreamAggregationLiveAggregation1216206343
    public class SingleStreamAggregationLiveAggregation1216206343 : Marten.Events.Aggregation.SyncLiveAggregatorBase<ClubMan.Shared.Model.Visitas>
    {
        private readonly Marten.Events.Aggregation.SingleStreamAggregation<ClubMan.Shared.Model.Visitas> _singleStreamAggregation;

        public SingleStreamAggregationLiveAggregation1216206343(Marten.Events.Aggregation.SingleStreamAggregation<ClubMan.Shared.Model.Visitas> singleStreamAggregation)
        {
            _singleStreamAggregation = singleStreamAggregation;
        }


        public System.Action<ClubMan.Shared.Model.Visitas, ClubMan.Shared.Events.VisitaSocioRegistradaEvent> Lambda1 {get; set;}


        public override ClubMan.Shared.Model.Visitas Build(System.Collections.Generic.IReadOnlyList<Marten.Events.IEvent> events, Marten.IQuerySession session, ClubMan.Shared.Model.Visitas snapshot)
        {
            if (!events.Any()) return null;
            ClubMan.Shared.Model.Visitas visitas = null;
            snapshot ??= Create(events[0], session);
            foreach (var @event in events)
            {
                snapshot = Apply(@event, snapshot, session);
            }

            return snapshot;
        }


        public ClubMan.Shared.Model.Visitas Create(Marten.Events.IEvent @event, Marten.IQuerySession session)
        {
            return new ClubMan.Shared.Model.Visitas();
        }


        public ClubMan.Shared.Model.Visitas Apply(Marten.Events.IEvent @event, ClubMan.Shared.Model.Visitas aggregate, Marten.IQuerySession session)
        {
            switch (@event)
            {
                case Marten.Events.IEvent<ClubMan.Shared.Events.VisitaSocioRegistradaEvent> event_VisitaSocioRegistradaEvent1:
                    Lambda1.Invoke(aggregate, event_VisitaSocioRegistradaEvent1.Data);
                    break;
            }

            return aggregate;
        }

    }

    // END: SingleStreamAggregationLiveAggregation1216206343
    
    
    // START: SingleStreamAggregationInlineHandler1216206343
    public class SingleStreamAggregationInlineHandler1216206343 : Marten.Events.Aggregation.AggregationRuntime<ClubMan.Shared.Model.Visitas, string>
    {
        private readonly Marten.IDocumentStore _store;
        private readonly Marten.Events.Aggregation.IAggregateProjection _projection;
        private readonly Marten.Events.Aggregation.IEventSlicer<ClubMan.Shared.Model.Visitas, string> _slicer;
        private readonly Marten.Internal.Storage.IDocumentStorage<ClubMan.Shared.Model.Visitas, string> _storage;
        private readonly Marten.Events.Aggregation.SingleStreamAggregation<ClubMan.Shared.Model.Visitas> _singleStreamAggregation;

        public SingleStreamAggregationInlineHandler1216206343(Marten.IDocumentStore store, Marten.Events.Aggregation.IAggregateProjection projection, Marten.Events.Aggregation.IEventSlicer<ClubMan.Shared.Model.Visitas, string> slicer, Marten.Internal.Storage.IDocumentStorage<ClubMan.Shared.Model.Visitas, string> storage, Marten.Events.Aggregation.SingleStreamAggregation<ClubMan.Shared.Model.Visitas> singleStreamAggregation) : base(store, projection, slicer, storage)
        {
            _store = store;
            _projection = projection;
            _slicer = slicer;
            _storage = storage;
            _singleStreamAggregation = singleStreamAggregation;
        }


        public System.Action<ClubMan.Shared.Model.Visitas, ClubMan.Shared.Events.VisitaSocioRegistradaEvent> Lambda1 {get; set;}


        public override async System.Threading.Tasks.ValueTask<ClubMan.Shared.Model.Visitas> ApplyEvent(Marten.IQuerySession session, Marten.Events.Projections.EventSlice<ClubMan.Shared.Model.Visitas, string> slice, Marten.Events.IEvent evt, ClubMan.Shared.Model.Visitas aggregate, System.Threading.CancellationToken cancellationToken)
        {
            switch (evt)
            {
                case Marten.Events.IEvent<ClubMan.Shared.Events.VisitaSocioRegistradaEvent> event_VisitaSocioRegistradaEvent2:
                    aggregate ??= new ClubMan.Shared.Model.Visitas();
                    Lambda1.Invoke(aggregate, event_VisitaSocioRegistradaEvent2.Data);
                    return aggregate;
            }

            return aggregate;
        }


        public ClubMan.Shared.Model.Visitas Create(Marten.Events.IEvent @event, Marten.IQuerySession session)
        {
            return new ClubMan.Shared.Model.Visitas();
        }

    }

    // END: SingleStreamAggregationInlineHandler1216206343
    
    
}
