import {ActionCreator, ActionType, on, On} from '@ngrx/store';
import {FunctionWithParametersType} from '@ngrx/store/src/models';
import produce, {Draft} from 'immer';

export class SharedUtils {
    static camelToKebabCase(str: string): string {
        return str.replace(/([a-z])([A-Z])/g, '$1-$2').toLowerCase();
    }
}

export function produceOn<Type extends string, C extends FunctionWithParametersType<any, object>, State>(
    actionType: ActionCreator<Type, C>,
    callback: (draft: Draft<State>, action: ActionType<ActionCreator<Type, C>>) => any
): On<State> {
    return on(actionType, (state: State, action): State => produce(state, (draft) => callback(draft, action)));
}
