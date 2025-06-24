using System.Text.Json;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ApiNgMovies.Utilitario
{
    public class TypeBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var propertyName = bindingContext.ModelName;
            var value = bindingContext.ValueProvider.GetValue(propertyName);

            if (value == ValueProviderResult.None)
            {
                return Task.CompletedTask;
            }

            try
            {
                var type = bindingContext.ModelMetadata.ModelType;
                var valueDeserialized = JsonSerializer.Deserialize(value.FirstValue!,type,new JsonSerializerOptions {PropertyNameCaseInsensitive = true});
                bindingContext.Result = ModelBindingResult.Success(valueDeserialized);
            }
            catch (Exception )
            {
                bindingContext.ModelState.TryAddModelError(propertyName, $"Error al deserializar {propertyName}, el valor dado no es del tipo adecuado.");
            }

            return Task.CompletedTask;
        }
    }
}
