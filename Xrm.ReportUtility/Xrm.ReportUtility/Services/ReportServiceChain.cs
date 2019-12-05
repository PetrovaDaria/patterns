using System;
using System.Collections.Generic;

namespace Xrm.ReportUtility.Services
{
    //  Цепочка обязанностей
    public class ReportServiceChain
    {
        private readonly ReportServiceHandler _handler;

        public ReportServiceChain(string[] args, string fileName)
        {
            _handler = new TxtHandler(null, args, fileName);
            _handler = new CsvHandler(_handler, args, fileName);
            _handler = new XlsxHandler(_handler, args, fileName);
        }

        public ReportServiceBase GetReportService()
        {
            return _handler.GetReportService();
        }
    }

    // Базовый класс определения ReportService'а
    public abstract class ReportServiceHandler
    {
        protected readonly ReportServiceHandler _nextHandler;
        protected readonly string[] _args;
        protected readonly string _fileName;
        protected abstract ReportServiceBase reportService { get; }
        protected ReportServiceHandler(ReportServiceHandler nextHandler, string[] args, string fileName)
        {
            _nextHandler = nextHandler;
            _args = args;
            _fileName = fileName;
        }

        public abstract ReportServiceBase GetReportService();
    }

    // Тут определяем ReportService по расширению файла
    // А можно было бы определить подкласс, который по чему-то другому определяет ReportService
    public abstract class FileEndHandler : ReportServiceHandler
    {
        protected FileEndHandler(ReportServiceHandler nextHandler, string[] args, string fileName) :
            base(nextHandler, args, fileName)
        {
        }
        protected abstract string fileEnd { get; }

        public string GetFileEnd(string fileName)
        {
            var fileParts = fileName.Split('.');
            return fileParts[fileParts.Length - 1];
        }

        public override ReportServiceBase GetReportService()
        {
            if (GetFileEnd(_fileName) == fileEnd)
            {
                return reportService;
            }

            return _nextHandler == null
                ? throw new NotSupportedException("this extension not supported")
                : _nextHandler.GetReportService();
        }
    }

    public class TxtHandler : FileEndHandler
    {
        public TxtHandler(ReportServiceHandler nextHandler, string[] args, string fileName) :
            base(nextHandler, args, fileName)
        {
        }

        protected override string fileEnd => "txt";
        protected override ReportServiceBase reportService => new TxtReportService(_args);
    }

    public class CsvHandler : FileEndHandler
    {
        public CsvHandler(ReportServiceHandler nextHandler, string[] args, string fileName) :
            base(nextHandler, args, fileName)
        {
        }

        protected override string fileEnd => "csv";
        protected override ReportServiceBase reportService => new CsvReportService(_args);
    }

    public class XlsxHandler : FileEndHandler
    {
        public XlsxHandler(ReportServiceHandler nextHandler, string[] args, string fileName) :
            base(nextHandler, args, fileName)
        {
        }

        protected override string fileEnd => "xlsx";
        protected override ReportServiceBase reportService => new XlsxReportService(_args);
    }
}
