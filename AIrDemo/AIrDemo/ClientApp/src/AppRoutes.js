import { IdentifyIndividual } from "./components/IdentifyIndividual";
import { FetchData } from "./components/FetchData";
import { Home } from "./components/Home";
import { AirHistory } from "./components/AirHistory";
import { Authorise } from "./components/Authorise";

const AppRoutes = [
    {
        index: true,
        element: <Home />
    },
    {
        path: '/authorise',
        element: <Authorise />
    },
    {
        path: '/identify-individual',
        element: <IdentifyIndividual />
    },
    {
        path: '/fetch-data',
        element: <FetchData />
    },
    {
        path: '/air-history',
        element: <AirHistory />
    }
];

export default AppRoutes;
