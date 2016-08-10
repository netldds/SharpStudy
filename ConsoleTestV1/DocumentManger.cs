using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConsole
{
    /// <summary>
    /// 泛型Generics的类，泛型约束
    /// </summary>
    /// <typeparam name="TDocument"></typeparam>
    public class DocumentManger<TDocument> where TDocument : IDocument
    {
        private readonly Queue<TDocument> documentQueue = new Queue<TDocument>();
        public void AddDocument(TDocument doc)
        {
            lock (this)
            {
                documentQueue.Enqueue(doc);
            }
        }
        public bool IsDocumentAvaiable
        {
            get { return documentQueue.Count > 0; }
        }
        public TDocument GetDocument()
        {
            TDocument doc = default(TDocument);
            lock (this)
            {
                doc = documentQueue.Dequeue();
            }
            return doc;
        }
        public void DisPlayAllDocuments()
        {
            foreach (TDocument doc in documentQueue)
            {
                Console.WriteLine(doc.Title);
            }
        }
    }
    public interface IDocument
    {
        string Title { get; set; }
        string Content { get; set; }
    }
    public class Document : IDocument
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public Document()
        {

        }
        public Document(string title, string content)
        {
            this.Title = title;
            this.Content = content;

        }

    }
}

