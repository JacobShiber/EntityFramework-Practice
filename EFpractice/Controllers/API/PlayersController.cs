using EFpractice.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace EFpractice.Controllers.API
{
    public class PlayersController : ApiController
    {
        SoccorContext dataContext = new SoccorContext();
        // GET: api/Players
        public IHttpActionResult Get()
        {
            try
            {
                return Ok(new {Massage = "Success", Players = dataContext.Players.ToList() });
            }
            catch(SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/Players/5
        public async Task<IHttpActionResult> GetById(int id)
        {
            try
            {
                Player expectedPlayer = await dataContext.Players.FindAsync(id);

                return Ok(new { Massage = "Success", expectedPlayer });
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/Players
        public async Task<IHttpActionResult> AddPlayer([FromBody]Player newPlayer)
        {
            try
            {
                dataContext.Players.Add(newPlayer);
                await dataContext.SaveChangesAsync();
                return Ok(new { Massage = "Success, new player added" });
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/Players/5
        [HttpPut]
        public async Task<IHttpActionResult> EditPlayer(int id, [FromBody]Player editedPlayer)
        {
            try
            {
                Player expectedPlayer = await dataContext.Players.FindAsync(id);
                expectedPlayer.FirstName = editedPlayer.FirstName;
                expectedPlayer.LastName = editedPlayer.LastName;
                expectedPlayer.Position = editedPlayer.Position;
                expectedPlayer.Age = editedPlayer.Age;

                await dataContext.SaveChangesAsync();

                return Ok(new { Massage = "Success, player been edited" });
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/Players/5
        public async Task<IHttpActionResult> Delete(int id)
        {
            try
            {
                Player playerToRemove = await dataContext.Players.FindAsync(id);
                dataContext.Players.Remove(playerToRemove);
                await dataContext.SaveChangesAsync();

                return Ok(new { Massage = "Success, player deleted" });
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
