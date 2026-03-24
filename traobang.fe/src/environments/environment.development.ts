import { IEnvironment } from "@/shared/models/environment.models";

export const environment: IEnvironment = {
    production: false,
    baseUrl: 'https://traobangapidev.huce.edu.vn',
    authGrantType: 'password',
    authClientId: 'client-web',
    authClientSecret: 'mBSQUHmZ4be5bQYfhwS7hjJZ2zFOCU2e',
    authScope: 'openid offline_access',
    appUrl: 'http://localhost:4200',
    grapeJsLicense: '25678fc14abc44f1824d13156e1b355f53988497d8354604a7cb3176a076c8e',
    minioUrl:'https://s3-2.huce.edu.vn:9000'
};
