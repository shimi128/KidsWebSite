using System.Collections.Generic;
using Examine;

namespace WebExtensions.Indexers
{
    public interface IExamineEventsConsumer
    {
        void OnGatheringNodeData(IndexingNodeDataEventArgs e);
        void OnDocumentWriting(Examine.LuceneEngine.DocumentWritingEventArgs e);

        IEnumerable<string> AppliedIndexes { get; }
    }
}
