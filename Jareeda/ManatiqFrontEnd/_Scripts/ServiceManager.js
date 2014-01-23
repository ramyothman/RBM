// serviceManager v 2.0
// Last edit by Ramy 2010-05-15

function serviceManager() {
    this.serviceUrl = null;
    this.data = null;
    this.run = function (divResult, successEvent, errorEvent) {
        
        $.ajax({
            type: "POST",
            url: this.serviceUrl,
            data: this.data,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (msg) {
                
                if (msg != null && divResult)
                {
                    
                    $("#" + divResult).append(msg.d);
                    
                }
                
                if ($.isFunction(successEvent))
                {
                    
                    successEvent(msg.d);
                    
                }
                    
            },
            error: function (jqXHR, textStatus, errorThrown) {
                //alert('error:' + jqXHR);
                //alert('error:' + textStatus);
                //alert('error:' + errorThrown);
                if ($.isFunction(errorEvent))
                    errorEvent(e);
            }

        });
    }
}