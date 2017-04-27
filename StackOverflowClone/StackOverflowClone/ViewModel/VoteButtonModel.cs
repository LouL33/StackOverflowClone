using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StackOverflowClone.Models;

namespace StackOverflowClone.ViewModel
{
    public class VoteButtonModel
    {
        public PostModel Post { get; set; }
        public int VoteValue { get; set; } = 0;
        public bool IsAllowedToVote { get; set; } = false;
    }
}