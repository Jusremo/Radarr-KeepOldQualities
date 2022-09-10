using System.Collections.Generic;
using NzbDrone.Core.ImportLists;

namespace Radarr.Api.V4.ImportLists
{
    public class ImportListBulkResource : ProviderBulkResource<ImportListBulkResource>
    {
        public bool? EnableAuto { get; set; }
        public string RootFolderPath { get; set; }
        public List<int> QualityProfileIds { get; set; }
    }

    public class ImportListBulkResourceMapper : ProviderBulkResourceMapper<ImportListBulkResource, ImportListDefinition>
    {
        public override List<ImportListDefinition> UpdateModel(ImportListBulkResource resource, List<ImportListDefinition> existingDefinitions)
        {
            if (resource == null)
            {
                return new List<ImportListDefinition>();
            }

            existingDefinitions.ForEach(existing =>
            {
                existing.EnableAuto = resource.EnableAuto ?? existing.EnableAuto;
                existing.RootFolderPath = resource.RootFolderPath ?? existing.RootFolderPath;
                existing.QualityProfileIds = resource.QualityProfileIds ?? existing.QualityProfileIds;
            });

            return existingDefinitions;
        }
    }
}
