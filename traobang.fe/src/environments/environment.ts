import { IEnvironment } from "@/shared/models/environment.models";

export const environment: IEnvironment = {
    production: true,
    baseUrl: 'https://traobangapi.huce.edu.vn',
    authGrantType: 'password',
    authClientId: 'client-web',
    authClientSecret: 'mBSQUHmZ4be5bQYfhwS7hjJZ2zFOCU2e',
    authScope: 'openid offline_access',
    appUrl: 'https://traobang.huce.edu.vn',
    grapeJsLicense: 'e80de4f218a64e5e8bb700503be4d05dd29f6ebce76f4d1e9025a050f0c267f0',
    minioUrl:'https://s3-2.huce.edu.vn:9000'
};
