using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;

namespace PhoneEdit.Helpers
{
    public class CustomMetadataProvider : IMetadataDetailsProvider, IDisplayMetadataProvider {
        public void CreateDisplayMetadata(DisplayMetadataProviderContext context) {

            if (context.Key.MetadataKind == ModelMetadataKind.Property) {

                context.DisplayMetadata.ConvertEmptyStringToNull = false;
            }
        }
    }
}
