using API.Common;
using API.Models;
using API.Services;
using API.Settings;
using MongoDB.Bson.IO;
using MongoDB.Driver;
using JsonLD;

using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Sockets;

namespace API.Processors
{
    public class RocketProcessor : IRocketProcessor
    {

        private readonly IRocketService _rocketService;

        /// <summary>
        /// MongoDB connection
        /// </summary>
        /// <param name="databaseSettings"></param>
        public RocketProcessor(IRocketService rocketService)
        {
            _rocketService = rocketService ?? throw new ArgumentNullException(nameof(rocketService));
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="rocketModel"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task Create(RocketModel rocketModel)
        {
            try
            {
                await _rocketService.Create(rocketModel);
            }
            catch (Exception ex) 
            {
                throw new Exception(ex.Message);
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task Delete(string id)
        {
            try
            {
                await _rocketService.Delete(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<JsonLdParser> Get(string id) {
            try {
               RocketModel rocket =  await _rocketService.Get(id);

                var parser = new JsonLdParser(rocket); // instantiaza parser-ul


                return parser; // returneaza parser-ul pentru a fii afisat
            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<JsonLdParser> GetAll()
        {
            try
            {
                List<RocketModel> rockets = await _rocketService.GetAll();

                var parser = new JsonLdParser(rockets); // instantiaza parser-ul

                return parser; // returneaza parser-ul pentru a fii afisat
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="rocketModel"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task Update(string id, RocketModel rocketModel)
        {

            try
            {
                await _rocketService.Update(id, rocketModel);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
