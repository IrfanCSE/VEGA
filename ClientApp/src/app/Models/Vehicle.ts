import { KeyValuePair } from './KeyValuePair';
import { Contact } from './Contact';

export interface Vehicle {
    id: number;
    make: KeyValuePair;
    model: KeyValuePair;
    isRegisterd: boolean;
    features: KeyValuePair[];
    contact: Contact;
}
