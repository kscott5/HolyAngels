import Vue from "vue";

export var adminConfig = {
    environment: 'development',
    loglevel: 1
}

export function consoleFormat(message: string, params?: any[]) {    
    switch(adminConfig.loglevel) {
        case 3: // LogLevel.WARN
            console.warn(message, params);
            break;

        case 4: //LogLevel.ERROR
            console.error(message, params);
            break;

        case 2: //LogLevel.INFO
            console.info(message, params);
            break;

        default:
            console.log(message, params);
    }
} // end consoleFormat

export class AdminPanel {
    constructor() {
        consoleFormat("AdminPanel has no base initialization at this time");
    }
    
    public loadview(selector: string) : boolean {        
        var element = document.querySelector(selector);
        if(!element) {
            consoleFormat("Failed querying dom for selector: $0", [selector]);
            return false;
        }

        new Vue({
            el: selector,
            data: {
                message: 'Hello :-)'
            }
        });

        return true;
    } // end loadView     
} // end AdminPanel
var panel = new AdminPanel();
export { AdminPanel as default};

