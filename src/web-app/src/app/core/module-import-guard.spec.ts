import {SharedModule} from '../shared/shared.module';
import {throwIfAlreadyLoaded} from './module-import-guard';


describe('throwIfAlreadyLoaded', () => {
  it('should throw an error if a module has already been loaded elsewhere', () => {
    const parentModule = new SharedModule();
    const moduleName = 'CoreModule';

    // THEN
    expect(() => throwIfAlreadyLoaded(parentModule, moduleName)).toThrowError(
      'CoreModule has already been loaded. Import Core modules in the AppModule only.'
    );
  });

  it('should NOT throw an error if a module has not been loaded elsewhere', () => {
    const parentModule = undefined;
    const moduleName = 'CoreModule';

    // THEN
    expect(() => throwIfAlreadyLoaded(parentModule, moduleName)).not.toThrowError(
      'CoreModule has already been loaded. Import Core modules in the AppModule only.'
    );
  });
});
