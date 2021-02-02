using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

using HobbyApp.DTO.Medias;

namespace HobbyApp.Controllers.Medias {
    [Route("[controller]")]
    [ApiController]
    public class MediasController : ControllerBase {
        private readonly IMediaService _MediaService;

        public MediasController(IMediaService MediaService) {
            _MediaService = MediaService;
        }

        [HttpGet]
        public ActionResult<List<MediaDTO>> GetAll() =>
            _MediaService.GetAll();

        [HttpGet("{id:length(24)}", Name = "GetMedia")]
        public ActionResult<MediaDTO> Get(string id) {
            MediaDTO media = _MediaService.GetByID(id);

            if (media == null)
                return NotFound("»»» [" + id + "] - Media not found! «««");

            return media;
        }

        [HttpPost]
        public ActionResult<MediaDTO> Create(CreateMediaDTO createMedia) {
            try {
                MediaDTO media = _MediaService.Create(createMedia);

                return CreatedAtRoute("GetMedia", new { id = media.Id.ToString() }, "»»» Media successfully created! «««");
            } catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, CreateMediaDTO mediaIn) {
            MediaDTO media = _MediaService.GetByID(id);

            if (media == null) {
                return NotFound("»»» [" + id + "] - Media not found! «««");
            }

            _MediaService.Update(id, mediaIn);
            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id) {
            MediaDTO media = _MediaService.GetByID(id);

            if (media == null) {
                return NotFound("»»» [" + id + "] - Media not found! «««");
            }

            _MediaService.RemoveByID(media.Id);
            return NoContent();
        }
    }
}