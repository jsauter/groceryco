using System.Collections.Generic;
using System.Linq;
using CsvHelper;
using GroceryCo.Core.Models;
using GroceryCo.Repositories.Interfaces;

namespace GroceryCo.Repositories
{
    public class RepositoryBase<T> : IRepository<T>
    {
        private IEnumerable<T> results;
        private IFileReaderBase _fileReader;

        public RepositoryBase(IFileReaderBase fileReader) 
        {
            _fileReader = fileReader;
        }

        public IEnumerable<T> GetItems()
        {
            if (results == null)
            {
                var csv = new CsvReader(_fileReader.GetTextReader());

                results = csv.GetRecords<T>().ToList();
            }

            return results;
        }
    }
}