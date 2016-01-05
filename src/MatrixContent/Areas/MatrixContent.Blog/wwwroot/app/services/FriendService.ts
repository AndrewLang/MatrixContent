
import {Person} from '../models/Person.ts';


export class FriendService {
    Persons: Array<Person>;

    constructor() {
        this.Persons = [
            new Person("Arav"),
            new Person("Martin"),
            new Person("Kai"),
            new Person("Andrew")
        ];
    }
}
