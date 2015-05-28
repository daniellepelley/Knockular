ko.bindingHandlers.dateString = {
    update: function (element, valueAccessor, allBindingsAccessor) {
        var value = valueAccessor(),
            allBindings = allBindingsAccessor();
        var valueUnwrapped = ko.utils.unwrapObservable(value);
        var format = allBindings.dateFormat || 'dd/MM/yyyy';

        if (valueUnwrapped !== null && valueUnwrapped !== undefined) {
            var date = Date.parse(valueUnwrapped);
            if (date !== null && date !== undefined) {
                $(element).text(date.toString(format));
            }
        }
    }
}