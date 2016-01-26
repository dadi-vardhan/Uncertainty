﻿using System;
using System.Linq;
using Microsoft.Research.Uncertain;
using Microsoft.Research.Uncertain.Inference;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UncertainTests
{
    [TestClass]
    public class MCMCTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var program = from a in new Flip(0.9)
                          from b in new Flip(0.9)
                          from c in new Flip(0.9)
                          select Convert.ToInt32(a) + Convert.ToInt32(b) + Convert.ToInt32(c);

            var sampler = new MarkovChainMonteCarloSampler<int>(program);

            var tmp = Microsoft.Research.Uncertain.Inference.Extensions.RunInference(sampler.Take(1000).ToList()).Support().ToList();

            var correct = program.Inference().Support().ToList();

            int x = 10;
        }
    }
}
