using System;
using Xrm.ReportUtility.Infrastructure.Transformers;
using Xrm.ReportUtility.Interfaces;
using Xrm.ReportUtility.Models;

namespace Xrm.ReportUtility.Infrastructure
{
    public class Builder
    {
        private IDataTransformer _service;
        private bool _hasAggFunc = false;
        private readonly ReportConfig _config;

        public Builder(IDataTransformer service, ReportConfig config)
        {
            _service = service;
            _config = config;
        }

        public Builder AddCostSum()
        {
            if (_config.WithData)
            {
                _hasAggFunc = true;
                _service = new WithDataReportTransformer(_service);
            }

            return this;
        }

        public Builder AddCountSum()
        {
            if (_config.CountSum)
            {
                _hasAggFunc = true;
                _service = new CountSumReportTransformer(_service);
            }

            return this;
        }

        public Builder AddVolumeSum()
        {
            if (_config.VolumeSum)
            {
                _hasAggFunc = true;
                _service = new VolumeSumReportTransformer(_service);
            }

            return this;
        }

        public Builder AddWeightSum()
        {
            if (_config.WeightSum)
            {
                _hasAggFunc = true;
                _service = new WeightSumReportTransfomer(_service);
            }

            return this;
        }

        public IDataTransformer Build()
        {
            if (_hasAggFunc)
            {
                return _service;
            }

            throw new Exception("At least one agg function should be used");
        }
    }
}
