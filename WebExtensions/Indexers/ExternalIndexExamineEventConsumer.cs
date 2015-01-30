using System.Collections.Generic;
using System.Text;
using Examine;
using Examine.LuceneEngine;

namespace WebExtensions.Indexers
{
    public class ExternalIndexExamineEventConsumer : IExamineEventsConsumer
    {
        private readonly string[] _indexers = new[] { "ExternalIndexer" };
        public void OnGatheringNodeData(IndexingNodeDataEventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var field in e.Fields)
            {
                sb.AppendLine(field.Value);

            }

            e.Fields.Add("_allContent", sb.ToString());


            if (e.Fields.ContainsKey("path"))
            {
                var path = e.Fields["path"];
                var fixedPath = string.Join(" ", path.Split(','));
                e.Fields.Add("_fixedPath", fixedPath);
            }
        }

        public void OnDocumentWriting(DocumentWritingEventArgs e)
        {

        }

        public IEnumerable<string> AppliedIndexes { get { return _indexers; } }
    }

}

