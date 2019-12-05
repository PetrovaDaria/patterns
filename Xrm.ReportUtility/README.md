Program.cs/GetReportService - переделала if в chain of responsibility, находится в Services/ReportServiceChain. Имя файла последовательно передается обработчиками друг другу. Если имя файла соответствует настройкам в обработчике, то возвращается ReportService, соответствующий обработчику. 

Infrastructre/DataTransformerCreator большой if, добавляющий функциональность разных DataTransformer'ов. Переписала на строителя в Infrastructure/Builder. В нем обязательно должен будет добавлен хотя бы один Transformer.

DataTransfomer и его подклассы - это декораторы, которые добавляют новые столбцы и агрегирующие функции. 

Services/ReportServiceBase/CreateReport - шаблонный метод. Использует GetDataRows переопределенный в разных подклассах. 