var AdminPanel = (function(){
    function AdminPanel() {        
    }
    
    AdminPanel.prototype.loadView = function loadView(selector) {
        var element = document.querySelector(selector);
        if(!element) return;

        new Vue({
            el: selector,
            data: {
                message: 'Get this party started'
            }
        });
    };
    
    return AdminPanel;
})();