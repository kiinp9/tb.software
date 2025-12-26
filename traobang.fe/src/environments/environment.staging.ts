import { IEnvironment } from "@/shared/models/environment.models";

export const environment: IEnvironment = {
    production: false,
    baseUrl: 'https://traobangapidev.huce.edu.vn',
    authGrantType: 'password',
    authClientId: 'client-web',
    authClientSecret: 'mBSQUHmZ4be5bQYfhwS7hjJZ2zFOCU2e',
    authScope: 'openid offline_access',
    appUrl: 'https://traobangdev.huce.edu.vn',
    grapeJsLicense: '595dab6755224886bd347acbc294204801a759defb92438b986d0ce1f5e506e9',
};
