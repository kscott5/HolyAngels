declare module HolyAngels {
    export var adminConfig;
    
    export function consoleFormat(message: string, params?: any[]);

    export interface IAdminPanel {
        loadView(selector: string) : boolean
    }

}