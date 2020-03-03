using IdeoTask.Services.CatalogService;
using IdeoTask.Services.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdeoTask.Logic.TreeStructure
{
    public class TreeGenerator : ITreeGenerator
    {
        private readonly ICatalogRepository _catalogRepository;

        public TreeGenerator(ICatalogRepository catalogRepository) {
            _catalogRepository = catalogRepository;
        }

        public List<Branch> GetTrees() {
            var treeList = _catalogRepository.GetAllCatalogs();
            return null;
        }

    }
}
