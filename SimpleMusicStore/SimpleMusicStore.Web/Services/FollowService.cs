﻿using SimpleMusicStore.Data;
using SimpleMusicStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleMusicStore.Web.Services
{
    public class FollowService
    {
        private SimpleDbContext _context;
        private RecordService _recordService;
        private ArtistService _artistService;
        private LabelService _labelService;

        public FollowService(SimpleDbContext context)
        {
            _context = context;
            _recordService = new RecordService(context);
            _artistService = new ArtistService(context);
            _labelService = new LabelService(context);
        }
        
        internal void WantRecord(int recordId, string userId)
        {
            if (!_recordService.IsValidRecordId(recordId))
            {
                return;
            }

            var recordUser = new RecordUser { RecordId = recordId, UserId = userId };

            if (_context.RecordUsers.Contains(recordUser))
            {
                return;
            }
            _context.RecordUsers.Add(recordUser);
            _context.SaveChanges();
        }

        internal void UnwantRecord(int recordId, string userId)
        {
            if (!_recordService.IsValidRecordId(recordId))
            {
                return;
            }

            var recordUser = new RecordUser { RecordId = recordId, UserId = userId };

            if (!_context.RecordUsers.Contains(recordUser))
            {
                return;
            }
            _context.RecordUsers.Remove(recordUser);
            _context.SaveChanges();

        }

        internal void FollowArtist(int artistId, string userId)
        {
            if (!_artistService.IsValidArtistId(artistId))
            {
                return;
            }

            var artistUser = new ArtistUser { ArtistId = artistId, UserId = userId };

            if (_context.ArtistUsers.Contains(artistUser))
            {
                return;
            }

            _context.ArtistUsers.Add(artistUser);
            _context.SaveChanges();
        }

        internal void UnfollowArtist(int artistId, string userId)
        {
            if (!_artistService.IsValidArtistId(artistId))
            {
                return;
            }

            var artistUser = new ArtistUser { ArtistId = artistId, UserId = userId };

            if (!_context.ArtistUsers.Contains(artistUser))
            {
                return;
            }

            _context.ArtistUsers.Remove(artistUser);
            _context.SaveChanges();
        }

        internal void FollowLabel(int labelId, string userId)
        {
            if (!_labelService.IsValidLabelId(labelId))
            {
                return;
            }
            var labelUser = new LabelUser { LabelId = labelId, UserId = userId };

            if (_context.LabelUsers.Contains(labelUser))
            {
                return;
            }

            _context.LabelUsers.Add(labelUser);
            _context.SaveChanges();
        }

        internal void UnfollowLabel(int labelId, string userId)
        {
            if (!_labelService.IsValidLabelId(labelId))
            {
                return;
            }

            var labelUser = new LabelUser { LabelId = labelId, UserId = userId };

            if (!_context.LabelUsers.Contains(labelUser))
            {
                return;
            }

            _context.LabelUsers.Remove(labelUser);
            _context.SaveChanges();
        }
    }
}