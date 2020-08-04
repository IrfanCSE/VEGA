import { Contact } from './Contact';
import { KeyValuePair } from './KeyValuePair';

export interface SaveVehicle {
    id: number;
    makeId: number;
    modelId: number;
    isRegisterd: boolean;
    features: number[];
    contact: Contact;
}
