using Newtonsoft.Json;
using System;
using System.Globalization;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Persons.CrossCutting.WebApiServices
{
    public class WebApiService : IWebApiService
    {
        public Uri UriBase { get; set; }

        public async Task<T> DeleteAsync<T>(string action)
        {
            using (var client = new HttpClient())
            {
                if (UriBase.ToString().EndsWith("/"))
                    action = $"{UriBase}{action}";
                else
                    action = $"{UriBase}/{action}";

                // Uri base
                //client.BaseAddress = UriBase;

                // Autenticação
                //if (TokensManager != null)
                //{
                //    client.DefaultRequestHeaders.Authorization = AuthenticationHeaderValue.Parse("Bearer " + TokensManager.CurrentUserAuthenticationToken.Value);
                //}

                // UI Current Culture
                client.DefaultRequestHeaders.Add("CurrentCultureName", CultureInfo.CurrentCulture.Name);

                // Post
                var response = await client.DeleteAsync(action);

                // Ok
                if (response.IsSuccessStatusCode)
                {
                    var myJsonString = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<T>(myJsonString);
                }

                // Error
                string error = await response.Content.ReadAsStringAsync();
                throw new Exception(response.StatusCode + Environment.NewLine + error);
            }
        }

        public async Task<T> GetAsync<T>(string action)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    if (UriBase.ToString().EndsWith("/"))
                        action = $"{UriBase}{action}";
                    else
                        action = $"{UriBase}/{action}";

                    // Uri base
                    //client.BaseAddress = UriBase;

                    // Autenticação (DESCOMENTAR ISSO AQUI DEPOIS QUE O LOGIN E AUTENTICAÇÃO ESTIVEREM PRONTOS!)
                    //if (TokensManager != null && TokensManager.CurrentUserAuthenticationToken != null)
                    //{
                    //    client.DefaultRequestHeaders.Authorization = AuthenticationHeaderValue.Parse("Bearer " + TokensManager.CurrentUserAuthenticationToken.Value);
                    //}

                    // UI Current Culture
                    client.DefaultRequestHeaders.Add("CurrentCultureName", CultureInfo.CurrentCulture.Name);

                    // Get
                    var response = await client.GetAsync(action, HttpCompletionOption.ResponseHeadersRead);
                    response.EnsureSuccessStatusCode();

                    if (response.IsSuccessStatusCode)
                    {
                        var myJsonString = await response.Content.ReadAsStringAsync();

                        if (!string.IsNullOrWhiteSpace(myJsonString))
                        {
                            try
                            {
                                var teste = JsonConvert.DeserializeObject<T>(myJsonString);
                                return teste;
                            }
                            catch (Exception)
                            {
                                return JsonConvert.DeserializeObject<T>(myJsonString);
                            }
                        }
                        else
                        {
                            // Error
                            throw new Exception(response.StatusCode + Environment.NewLine + "Nenhum registro encontrado");
                        }
                    }

                    // Error
                    string error = await response.Content.ReadAsStringAsync();
                    throw new Exception(response.StatusCode + Environment.NewLine + error);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + $"{UriBase}{action}" + " ::." + ex.InnerException);
            }
        }

        public async Task<T> GetAsync<T>(string action, object data)
        {
            try
            {
                var json = JsonConvert.SerializeObject(data);

                using (var httpClient = new HttpClient())
                {
                    if (UriBase.ToString().EndsWith("/"))
                        action = $"{UriBase}{action}";
                    else
                        action = $"{UriBase}/{action}";

                    httpClient.Timeout = TimeSpan.FromHours(1);
                    var stringContent = new StringContent(json, Encoding.UTF8);
                    stringContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    var response = httpClient.PostAsync(action, stringContent);
                    var dados = response.Result.Content.ReadAsStringAsync();




                    //using (var client = new HttpClient())
                    //{
                    //    // Uri base
                    //    client.BaseAddress = UriBase;
                    //    //client.Timeout = TimeSpan.FromMinutes(10);

                    //    // Autenticação
                    //    //if (TokensManager != null)
                    //    //{
                    //    //    client.DefaultRequestHeaders.Authorization = AuthenticationHeaderValue.Parse("Bearer " + TokensManager.CurrentUserAuthenticationToken.Value);
                    //    //}

                    //    // UI Current Culture
                    //    client.DefaultRequestHeaders.Add("CurrentCultureName", CultureInfo.CurrentCulture.Name);

                    //    // Post
                    //    var content = sendMessageAsJson(data);
                    //    var response = await client.PostAsync(action, content);

                    //    response.EnsureSuccessStatusCode();

                    // Ok
                    //if (response.IsSuccessStatusCode)
                    var resultado = response.Result;
                    if (resultado.IsSuccessStatusCode)
                    {
                        var myJsonString = await resultado.Content.ReadAsStringAsync();

                        if (!string.IsNullOrWhiteSpace(myJsonString))
                        {
                            try
                            {
                                return JsonConvert.DeserializeObject<T>(myJsonString);
                            }
                            catch (Exception e)
                            {
                                return JsonConvert.DeserializeObject<T>(myJsonString);
                            }
                        }
                        else
                        {
                            // Error
                            throw new Exception(resultado.StatusCode + Environment.NewLine + "Nenhum registro encontrado");
                        }
                    }

                    // Error
                    string error = await resultado.Content.ReadAsStringAsync();
                    throw new Exception(resultado.StatusCode + Environment.NewLine + error + $"{UriBase}{action}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + $"{UriBase}{action}" + " ::." + ex.InnerException);
            }
        }

        

        public async Task<T> PostAsync<T>(string action, object data)
        {
            using (var client = new HttpClient())
            {
                if (UriBase.ToString().EndsWith("/"))
                    action = $"{UriBase}{action}";
                else
                    action = $"{UriBase}/{action}";

                // UI Current Culture
                client.DefaultRequestHeaders.Add("CurrentCultureName", CultureInfo.CurrentCulture.Name);

                var content = sendMessageAsJson(data);
                var response = await client.PostAsync(action, content);

                // Ok
                if (response.IsSuccessStatusCode)
                {
                    var myJsonString = await response.Content.ReadAsStringAsync();

                    return JsonConvert.DeserializeObject<T>(myJsonString);
                }

                // Error
                string error = await response.Content.ReadAsStringAsync();
                throw new Exception(response.StatusCode + Environment.NewLine + error);
            }
        }

        public async Task<T> PutAsync<T>(string action, T data)
        {
            using (var client = new HttpClient())
            {
                if (UriBase.ToString().EndsWith("/"))
                    action = $"{UriBase}{action}";
                else
                    action = $"{UriBase}/{action}";

                // Uri base
                //client.BaseAddress = UriBase;

                // Autenticação
                //if (TokensManager != null)
                //{
                //    client.DefaultRequestHeaders.Authorization = AuthenticationHeaderValue.Parse("Bearer " + TokensManager.CurrentUserAuthenticationToken.Value);
                //}

                // UI Current Culture
                client.DefaultRequestHeaders.Add("CurrentCultureName", CultureInfo.CurrentCulture.Name);

                // Tratamento
                var jsonString = JsonConvert.SerializeObject(data);
                var httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");

                //HTTP POST
                var content = sendMessageAsJson(data);
                var putTask = client.PutAsync(action, content);
                putTask.Wait();

                var response = putTask.Result;

                // Ok
                if (response.IsSuccessStatusCode)
                {
                    var myJsonString = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<T>(myJsonString);
                }

                // Error
                string error = await response.Content.ReadAsStringAsync();
                throw new Exception(response.StatusCode + Environment.NewLine + error);
            }
        }


        public ByteArrayContent sendMessageAsJson(object data)
        {
            var objectSerialize = JsonConvert.SerializeObject(data);
            var buffer = Encoding.UTF8.GetBytes(objectSerialize);
            var byteContent = new ByteArrayContent(buffer);
            byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            return byteContent;
        }
    }
}
