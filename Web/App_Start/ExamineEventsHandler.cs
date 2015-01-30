using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Examine;
using Examine.LuceneEngine.Providers;
using Examine.Providers;
using Umbraco.Core.Logging;
using WebExtensions.Indexers;

namespace Web.App_Start
{
    public class ExamineEventsHandler
    {
        private static IEnumerable<IExamineEventsConsumer> _examineEventsConsumers;

        public static void Init()
        {
            _examineEventsConsumers = DependencyResolver.Current.GetServices<IExamineEventsConsumer>();
            foreach (var indexer in ExamineManager.Instance.IndexProviderCollection as IEnumerable<BaseIndexProvider>)
            {

                indexer.GatheringNodeData += ExamineEventsHandler_GatheringNodeData;
                ((LuceneIndexer)indexer).DocumentWriting += ExamineEventsHandler_DocumentWriting;
            }
        }


        static void ExamineEventsHandler_DocumentWriting(object sender, Examine.LuceneEngine.DocumentWritingEventArgs e)
        {
            var indexer = sender as BaseIndexProvider;

            if (indexer == null)
                return;


            foreach (var examineEventsConsumer in _examineEventsConsumers)
            {
                if (examineEventsConsumer.AppliedIndexes.Contains(indexer.Name))

                    try
                    {
                        examineEventsConsumer.OnDocumentWriting(e);
                    }
                    catch (Exception exception)
                    {
                        LogHelper.Error<ExamineEventsHandler>("Error With Event Consumer", exception);
                    }

            }
        }

        static void ExamineEventsHandler_GatheringNodeData(object sender, IndexingNodeDataEventArgs e)
        {
            var indexer = sender as BaseIndexProvider;

            if (indexer == null)
                return;

            foreach (var examineEventsConsumer in _examineEventsConsumers)
            {
                if (examineEventsConsumer.AppliedIndexes.Contains(indexer.Name))
                    try
                    {
                        examineEventsConsumer.OnGatheringNodeData(e);
                    }
                    catch (Exception exception)
                    {
                        LogHelper.Error<ExamineEventsHandler>("Error With Event Consumer", exception);
                    }
            }

        }
    }
}