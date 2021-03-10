const { pathsToModuleNameMapper } = require('ts-jest/utils');
const { compilerOptions } = require('./tsconfig.json');

/**
 * Use jest Framework instead of Karma and Jasmine
 * Faster experience, simple faking, spying and mocking ...
 * To see jest configuration
 * https://itnext.io/angular-testing-series-how-to-add-jest-to-angular-project-smoothly-afffd77cc1cb
 * */
module.exports = {
    preset: 'jest-preset-angular',
    roots: ['<rootDir>/src/'],
    testMatch: ['**/+(*.)+(spec).+(ts)'],
    setupFilesAfterEnv: ['<rootDir>/src/test.ts'],
    collectCoverage: true,
    coverageReporters: ['html'],
    coverageDirectory: 'coverage/my-app',
    moduleNameMapper: pathsToModuleNameMapper(compilerOptions.paths || {}, {
        prefix: '<rootDir>/',
    }),
};
